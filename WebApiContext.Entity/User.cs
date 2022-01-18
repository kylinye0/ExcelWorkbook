using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiContext.Entity
{
    public class User
    {
        public int ID { get; set; }
        public Guid UserNo { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public bool UserLock { get; set; }
        public int SafeLevel { get; set; }
        public string TwoValidPassword { get; set; }

    }
}
