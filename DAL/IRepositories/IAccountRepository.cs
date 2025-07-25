﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IAccountRepository
    {
        Task<Member?> GetMember( string email ); 
        Task<Member> CreateMember( Member member );
    }
}
