using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hummingbird.DM.Extensions.Interop.CMSFORM;
using Hummingbird.DM.Extensions.Interop.DOCSObjects;
using Hummingbird.DM.Extensions.Interop.VBFORMS;

namespace cmdCustomSearch
{
    public class CustomSearch : SearchCriteriaFormInternal
    {
        public short ShowSearchCriteriaForm(Hummingbird.DM.Extensions.Interop.VBFORMS.ISearch pSearch, bool bAllowEdits)
        {
            frmCustomSearchForm objSearchForm = new frmCustomSearchForm();
            objSearchForm.init((Hummingbird.DM.Extensions.Interop.VBFORMS.ISearch)pSearch);
            objSearchForm.ShowDialog();
            if (objSearchForm.bOK)
                return 1;
            else
                return 0;
        }
    }
}
