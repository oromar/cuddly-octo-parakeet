using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Models;
using WorkSchedule.Infra.Context;

namespace WorkSchedule.Infra.Repositories
{
    public class SettingsRepository : BaseRepository<Settings>
    {
        public SettingsRepository(WorkScheduleContext context) : base(context)
        {
        }
    }
}
