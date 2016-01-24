using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using SimpleInjector;

namespace WorkerRoleTestDI_Entity
{
    class JobFactory : SimpleJobFactory
    {
        private readonly Container container;

        public JobFactory(Container container)
        {
            this.container = container;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                IJob result;

                result = (IJob)this.container.GetInstance(bundle.JobDetail.JobType);


                return result;
            }
            catch (Exception ex)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the NinjectJobFactory.", bundle.JobDetail.Key), ex);
            }
        }
    }
}
