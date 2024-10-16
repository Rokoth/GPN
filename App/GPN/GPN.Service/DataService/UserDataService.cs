using GPN.Db.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Service.DataService
{
    public class UserDataService(IRepository<DB.Model.User> userRepository)
    {
        private readonly IRepository<DB.Model.User> _userRepository = userRepository;

        public async Task<Contract.Models.Response<Contract.Models.User>> GetUserAsync(Guid id)
        {
            CancellationTokenSource cts = new();

            try
            {
                var result = await _userRepository.GetAsync(id, cts.Token);
                if (result == null)
                {
                    return Contract.Models.Response<Contract.Models.User>.Error($"Пользователь с id = {id} не найден");
                }

                return Contract.Models.Response<Contract.Models.User>.Ok(MapUserItem(result));

            }
            catch (Exception ex)
            {
                return Contract.Models.Response<Contract.Models.User>.Error(ex.Message);
            }
        }

        //todo: маппинг всех полей
        private static Contract.Models.User MapUserItem(DB.Model.User result)
        {
            return new Contract.Models.User()
            {
                Id = result.Id,
                Name = result.NoneField,
            };
        }
    }
}
