﻿using System;
using Microsoft.AspNetCore.Identity;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.DAL.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
    }
}