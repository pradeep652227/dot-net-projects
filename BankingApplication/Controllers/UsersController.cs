using System;
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
                                        on us.accountType equals at.accountTypeId
                                        join bk in banks
                                        on us.bankId equals bk.bankId
                                        join ur in userRoles
                                        on us.roleId equals ur.roleId
                                        select new User_AccountType()
                                        {
                                            user = us,
                                            accountType = at.accountTypeName,
                                            userBank = bk.bankName,
                                            userRole = ur.roleName
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
                .Include(u=>u.Address)
                .FirstOrDefaultAsync(m => m.userId == id);

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

            ViewData["Method"] = "Create";
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

                user.addressId = address.addressId;
                _context.Add(user);
                await _context.SaveChangesAsync();

                address.userId = user.userId;
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

            ViewData["Method"] = "Create";
            return View(Users_BanksModel);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                                     .Include(u=>u.Role)
                                     .Include(u=>u.UserAccount)
                                     .Include(u=>u.Bank)
                                     .Include(u=>u.Address)
                                     .FirstOrDefaultAsync(u=>u.userId==id);
            if (user == null)
            {
                return NotFound();
            }

            IQueryable<Bank> banks = _context.Banks;
            IQueryable<AccountType> accountTypes = _context.AccountTypes;
            IQueryable<UserRole> userRoles = _context.UserRoles;
            var Users_BanksModel = new User_CreateView()
            {
                user = user,
                banks = banks,
                accountTypes = accountTypes,
                userRoles = userRoles,
                userAddress = user.Address
            };

            ViewData["Method"] = "Edit";
            return View("Create",Users_BanksModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User_CreateViewDTO userWithFullDetails)
        {
            IQueryable<Bank> banks = _context.Banks;
            IQueryable<AccountType> accountTypes = _context.AccountTypes;
            IQueryable<UserRole> userRoles = _context.UserRoles;
            var Users_BanksModel = new User_CreateView()
            {
                user = userWithFullDetails.user,
                banks = banks,
                accountTypes = accountTypes,
                userRoles = userRoles,
                userAddress = userWithFullDetails.user.Address
            };

            ViewData["Method"] = "Edit";

            if (ModelState.IsValid)
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    var address = userWithFullDetails.userAddress;
                    var user = userWithFullDetails.user;

                    if(user.userId==0 || address.addressId == 0)
                    {
                        await transaction.RollbackAsync();
                        //send a custom message on the screen like Server Error
                        return View("Create", Users_BanksModel);
                    }
                    _context.Addresses.Update(address);

                    _context.Users.Update(user);

                    await _context.SaveChangesAsync();

                    //commit transaction
                    await transaction.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //rollback the transaction
                    await transaction.RollbackAsync();

                    if (!UserExists(userWithFullDetails.user.userId))
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


            return View("Create", Users_BanksModel);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.userId == id);
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
            var address = await _context.Addresses.FindAsync(user.addressId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.userId == id);
        }
    }
}
