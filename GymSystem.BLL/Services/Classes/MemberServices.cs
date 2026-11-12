using GymSystem.BLL.Services.Interfaces;
using GymSystem.DAL.Entities;
using GymSystem.DAL.Repositories.Classes;
using GymSystem.DAL.Repositories.Interfaces;
using GymSystemG03.BLL.ViewModels.MembersViewModels;

namespace GymSystem.BLL.Services.Classes
{
    public class MemberServices : IMemberServices
    {
        private readonly IGenericRepository<Member> memberRepository;
        private readonly IGenericRepository<MemberShip> memberShipRepository;
        private readonly IGenericRepository<Plan> pLanrepository;
        private readonly IGenericRepository<HealthRecord> healthRecordRepository;
        private readonly IGenericRepository<Booking> bookingRepository;

        public MemberServices(IGenericRepository<Member> memberrepository, IGenericRepository<MemberShip> MemberShipRepository,
            IGenericRepository<Plan> PLanrepository,IGenericRepository<HealthRecord> HealthRecordRepository,IGenericRepository<Booking>BookingRepository)
        {
            this.memberRepository = memberrepository;
            memberShipRepository = MemberShipRepository;
            pLanrepository = PLanrepository;
            healthRecordRepository = HealthRecordRepository;
            bookingRepository = BookingRepository;
        }

        //get
        public async Task<IEnumerable<MemberViewModel>> GetallmembersAsync(CancellationToken ct = default)
        {
            var members = await memberRepository.GetAll(false, ct);
            if (!members.Any()) return [];

            var MembersViewModel = members.Select(m => new MemberViewModel()
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                Photo = m.Photo,
                Gender = m.Gender.ToString(),

            });
            return MembersViewModel;
        }

        public async Task<MemberViewModel?> GetmemberdetailsAsync(int memberId, CancellationToken ct = default)
        {
            var member = await memberRepository.GetById(memberId, ct);
            if (member == null) return null;
            var MemberVm = new MemberViewModel()
            {
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Gender = member.Gender.ToString(),
                Address = $"{member.Address.BuildingNumber}-{member.Address.Street}-{member.Address.City}"
            };
            var activeMembership = await memberShipRepository.FirstOrDefaultAsync(mb => mb.MemberId == memberId && mb.EndDate > DateTime.Now, false, ct);
            if (activeMembership is not null)
            {
                var activePlan = await pLanrepository.GetById(activeMembership.planId, ct);

                MemberVm.PlanName = activePlan?.Name;
                MemberVm.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                MemberVm.MembershipEndDate = activeMembership.EndDate.ToShortDateString();

            }
            return MemberVm;
        }

        public async Task<HealthRecordViewModel?> GetMemberhealthRecordasync(int memberId, CancellationToken ct = default)
        {
            var record = await healthRecordRepository.FirstOrDefaultAsync(r=>r.MemberId== memberId, false, ct);
            if (record is null) return null;

            return new HealthRecordViewModel()
            {
                Weight = record.Weight,
                BloodType = record.BloodType,
                Height = record.Height,
                Note = record.Note,
            };
            
            
        }

        public async Task<MemberToUpdateViewModel?> GetmemberToupadteAsync(int memberId, CancellationToken ct = default)
        {
            var member = await memberRepository.GetById(memberId, ct);
            if(member is null) return null;
            return new MemberToUpdateViewModel()
            {
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Photo = member.Photo,
                Street = member.Address.Street,
                BuildingNumber= member.Address.BuildingNumber,
                City = member.Address.City

            };
        }
        //post
        public async Task<bool> UpdateMemberAsync(int id, MemberToUpdateViewModel model, CancellationToken ct = default)
        {
            var member = await memberRepository.GetById(id, ct);
            if (member is null)
                return false;
            if (await memberRepository.Anyasync(m => m.Email == model.Email && m.Id != id)) return false;
            if (await memberRepository.Anyasync(m => m.Phone == model.Phone && m.Id != id)) return false;

            member.Email = model.Email;
            member.Phone = model.Phone;
            member.Name = model.Name;
            member.Photo = model.Photo;
            member.Address.BuildingNumber = model.BuildingNumber;
            member.Address.Street = model.Street;
            member.Address.City = model.City;
            member.UpdatedAt = DateTime.Now;
            
             memberRepository.Update(member);

            var result = await memberRepository.CompleteAsync();
            return result > 0;
        }

        public async Task<bool> CreateMemberAsync(CreateMemberViewModel model, CancellationToken ct = default)
        {
            var EamilExists = await memberRepository.Anyasync(m => m.Email == model.Email, ct);
            var phoneExists = await memberRepository.Anyasync(m => m.Phone == model.Phone, ct);
            if (EamilExists || phoneExists) return false;

            var Member = new Member()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Address = new Address()
                {
                    BuildingNumber = model.BuildingNumber,
                    City = model.City,
                    Street = model.Street
                },
                HealthRecord = new HealthRecord()
                {
                    Weight = model.HealthRecordViewModel.Weight,
                    Height = model.HealthRecordViewModel.Height,
                    Note = model.HealthRecordViewModel.Note,
                    BloodType = model.HealthRecordViewModel.BloodType


                }

            };
            memberRepository.Add(Member);
            var result = await memberRepository.CompleteAsync();
            return result > 0;
        }

        public async Task<bool> DeleteMemberAsync(int memberId, CancellationToken ct = default)
        {
            var HasFutureSession= await bookingRepository.Anyasync(b=>b.MemberId==memberId && b.Session.EndDate>DateTime.Now) ;
            if (HasFutureSession) return false;
            memberRepository.Delete(memberId);
            var result = await memberRepository.CompleteAsync();
            return result > 0;
        }

    }
}
