using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankApp_WebAPI.Models;

namespace BankApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly BankContext _context;
        int count = 0;
        AccountFactory accountFactory = new AccountFactory();

        public BankAccountsController(BankContext context)
        {
            _context = context;
        }

        // GET: api/BankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetAccountList()
        {
          if (_context.AccountList == null)
          {
              return NotFound();
          }
            return await _context.AccountList.ToListAsync();
        }

        // GET: api/BankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
          if (_context.AccountList == null)
          {
              return NotFound();
          }
            var bankAccount = await _context.AccountList.FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return bankAccount;
        }

        // PUT: api/BankAccounts/deposit/5/1000
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("deposit/{id}/{amount}")]
        public async Task<IActionResult> PutBankAccountD(int id, double amount)
        {
            Console.WriteLine(id + " " + amount);
            var bankAccount = await _context.AccountList.FindAsync(id);

            if(bankAccount == null)
                return NotFound();
            try
            {
                /*bankAccount.deposit(amount);*/
                bankAccount.trans.onDepositMoney(amount);
                await _context.SaveChangesAsync();
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return NoContent();
        }

        // PUT: api/BankAccounts/withdraw/5/1000
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("withdraw/{id}/{amount}")]
        public async Task<IActionResult> PutBankAccountW(int id, double amount)
        {
            Console.WriteLine(id + " " + amount);
            var bankAccount = await _context.AccountList.FindAsync(id);

            if (bankAccount == null)
                return NotFound();
            try
            {
                /*bankAccount.withdraw(amount);*/
                bankAccount.trans.onWithdrawMoney(amount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return NoContent();
        }

        // POST: api/BankAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankAccount)
        {
            if (_context.AccountList == null)
            {
                return Problem("Entity set 'BankContext.AccountList'  is null.");
            }
            bankAccount = accountFactory.getBankAccount(bankAccount);
            bankAccount.AccountNo = ++this.count;
            _context.AccountList.Add(bankAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankAccount", new { id = bankAccount.Id }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            if (_context.AccountList == null)
            {
                return NotFound();
            }
            var bankAccount = await _context.AccountList.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.AccountList.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankAccountExists(int id)
        {
            return (_context.AccountList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
