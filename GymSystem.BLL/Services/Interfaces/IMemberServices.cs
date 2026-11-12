using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystemG03.BLL.ViewModels.MembersViewModels;

namespace GymSystem.BLL.Services.Interfaces
{
    public  interface IMemberServices
    {
        //Get Model -> viewmodel -> view
        Task<IEnumerable<MemberViewModel>>GetallmembersAsync(CancellationToken ct=default);

        
       Task<MemberViewModel?> GetmemberdetailsAsync(int id, CancellationToken ct = default);

        Task<MemberToUpdateViewModel?> GetmemberToupadteAsync(int id, CancellationToken ct = default);

        Task<HealthRecordViewModel?> GetMemberhealthRecordasync(int id, CancellationToken ct = default);
        //post viewmodel->model->DB
        Task<bool> CreateMemberAsync(CreateMemberViewModel model, CancellationToken ct = default);

        Task<bool> UpdateMemberAsync(int id, MemberToUpdateViewModel model, CancellationToken ct = default);

        Task<bool> DeleteMemberAsync(int id, CancellationToken ct = default);
    }
}
