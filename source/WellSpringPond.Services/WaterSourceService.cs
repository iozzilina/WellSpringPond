namespace WellSpringPond.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WellSpringPond.Data;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.WaterSources;

    public class WaterSourceService : Service
    {
      
        public IEnumerable<WaterSourcesBasicDataVm> GetWsBasicData()
        {
            IEnumerable<WaterSource> waters = this.Context.WaterSources;

            IEnumerable<WaterSourcesBasicDataVm> vms =
                Mapper.Map<IEnumerable<WaterSource>, IEnumerable<WaterSourcesBasicDataVm>>(waters);

            return vms;
        }


        public WaterSourcesAdminDataVm GetWsAdminData(int id)
        {
            WaterSource ws = this.Context.WaterSources.Find(id);

            if (ws == null)
            {
                return null;
            }

            WaterSourcesAdminDataVm vm = Mapper.Map<WaterSource, WaterSourcesAdminDataVm>(ws);

            return vm;

        }

        
    }
}
