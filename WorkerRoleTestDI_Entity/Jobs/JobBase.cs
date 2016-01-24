using Quartz;

namespace WorkerRoleTestDI_Entity.Jobs
{
    public abstract class JobBase : IJobBase
    {
        public abstract void Execute(IJobExecutionContext context);
    }
}