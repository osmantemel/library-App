using libData.Abstract;
using libEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libData.Concrete
{
    public class loginAdminControl : IadminRepo
    {
      
        public int loginAdminYesNo(loginAdmin loginAdmin)
        {
            var context = new libContext();
            
            loginAdmin loginAdmin1= context.loginAdmin.FirstOrDefault(p => p.usarName == loginAdmin.usarName);

            if (loginAdmin == null)
            {
                return 0;
            }
            else if (loginAdmin1 == null)
            {
                return 0;
            }
            else if(loginAdmin.usarName==loginAdmin1.usarName && loginAdmin.password==loginAdmin1.password)
            {
                return 1;
            }
            else
            {
                return 0;
            }


        }
    }
}
