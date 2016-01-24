using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Quartz;
using Quartz.Impl;
using SimpleInjector;
using WorkerRoleTestDI_Entity.Jobs;

namespace WorkerRoleTestDI_Entity
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private Container container;
        private IScheduler scheduler;
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Bootstrap();
            scheduler = container.GetInstance<IScheduler>();


            // Below this line should be whatever code you are using today to schedule jobs, triggers, etc. and start the scheduler. This is just here for context

            // add jobs and start scheduler
            scheduler.ScheduleJob(
                JobBuilder.Create<JobNotification>().Build(),
                TriggerBuilder.Create().WithSimpleSchedule(
                    
                    s => s.WithIntervalInSeconds(60)).Build());

            // start scheduler
            scheduler.Start();


            Trace.TraceInformation("WorkerRoleTestDI_Entity has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRoleTestDI_Entity is stopping");
            scheduler.Shutdown();
            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRoleTestDI_Entity has stopped");
        }

        public override void Run()
        {
            Trace.TraceInformation("WorkerRoleTestDI_Entity is running");
 
            try
            {

                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        private void Bootstrap()
        {
            container = new Container();
         //   container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            Common.SimpleInjectorCommon.RegisterItems(container, Lifestyle.Singleton);
            container.Register<IJob, JobNotification>(Lifestyle.Singleton);


            var sched = new StdSchedulerFactory().GetScheduler();
            sched.JobFactory = new JobFactory(container);

            container.RegisterSingleton(typeof(IScheduler), sched);

            container.Verify();
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}