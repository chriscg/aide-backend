using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsWorkplaceAuditKeys
	{

		#region Data Members

		int _empID;

		#endregion

        #region Constructor

        public clsWorkplaceAuditKeys(int empID)
        {
            _empID = empID;
        }
		#endregion

        #region Properties

        public int EMP_ID
        {
            get { return _empID; }
        }


		#endregion

	}
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////