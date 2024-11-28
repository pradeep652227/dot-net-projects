﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingApplication.Data;
using BankingApplication.Models;
using BankingApplication.Models.Non_Table_Models.Users;
using BankingApplication.Models.DTOs.UserDTOs;

namespace BankingApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly BankingApplicationContext _context;

        public UsersController(BankingApplicationContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            IQueryable<User> users = _context.Users;
            IQueryable<AccountType> accountTypes = _context.AccountTypes;
            IQueryable<Bank> banks = _context.Banks;
            IQueryable<UserRole> userRoles = _context.UserRoles;

            var usersWithAccountType = (from us in users
                                        join at in accountTypes
                                        on us.AccountType equals at.AccoutnTypeId
                                        join bk in banks
                                        on us.BankId equals bk.BankId
                                        join ur in userRoles
                                        on us.RoleId equals ur.RoleId
                                        select new User_AccountType()
                                        {
                                            user = us,
                                            accountType = at.AccountTypeName,
                                            userBank = bk.BankName,
                                            userRole = ur.RoleName
                                        }).ToList();

            return View(usersWithAccountType);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Bank)
                .Include(u => u.UserAccount)
                .FirstOrDefaultAsync(m => m.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            IQueryable<Bank> banks = _context.Banks;
            IQueryable<AccountType> accountTypes = _context.AccountTypes;
            IQueryable<UserRole> userRoles = _context.UserRoles;
            var Users_BanksModel = new User_CreateView()
            {
                user = new User(),
                banks = banks,
                accountTypes = accountTypes,
                userRoles = userRoles,
                userAddress = new Address()
            };

            return View(Users_BanksModel);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( User_CreateViewDTO userWithAddress)
        {

            if (ModelState.IsValid)
            {
                var user = userWithAddress.user;
                var address = userWithAddress.userAddress;

                _context.Add(address);
                await _context.SaveChangesAsync();

                user.AddressId = address.addressId;
                _context.Add(user);
                await _context.SaveChangesAsync();

                address.userId = user.UserId;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            IQueryable<Bank> banks = _context.Banks;
            IQueryable<AccountType> accountTypes = _context.AccountTypes;
            IQueryable<UserRole> userRoles = _context.UserRoles;
            var Users_BanksModel = new User_CreateView()
            {
                user = new User(),
                banks = banks,
                accountTypes = accountTypes,
                userRoles = userRoles,
                userAddress = new Address()
            };

            return View(Users_BanksModel);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,FirstName,LastName,RoleId,Email,Password,AccountType,CurrentBalance,BankId")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
