﻿using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface IAdminManager
    {
        AdminRegistration AddAdmin(AdminRegistration objAdmin);
    }
}
