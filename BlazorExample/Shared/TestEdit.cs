﻿using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExample.Shared
{
    [Serializable]
    public class TestEdit : BusinessBase<TestEdit>
    {
        [Create]
        [RunLocal]
        private void Create([Inject] IDataPortal<UserEdit> userEdit)
        {
           
        }
    }
}
