using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Business;
using DataAccess;
using Quartz;

namespace WorkerRoleTestDI_Entity.Jobs
{
    public class JobNotification : JobBase, IJobBase
    {
        private IPersonService personService;

        public JobNotification(IPersonService personService)
        {
            this.personService = personService;
        }

        public override void Execute(IJobExecutionContext context)
        {
            try
            {
                IEnumerable<Person> people = personService.GetAll();
                Person person;
                for (int i = 0; i < 100; i++)
                {
                    person = people.ElementAt(i);
                    Trace.WriteLine(string.Format("{0} {1}", person.FirstName, person.LastName));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}