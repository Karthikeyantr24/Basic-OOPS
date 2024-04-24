using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum Gender { Select, Male, Female, Transgender }

namespace BankAccount
{
    public class CustomerDetails
    {
        private  static int _customerId = 1000;

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime Dob { get; set; }

        public CustomerDetails(string customerName, int balance, Gender gender, long phone,
        string mailId, DateTime dob)
        {
            _customerId++;
            CustomerId = "HDFC" + _customerId;

            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailId = mailId;
            Dob = dob;
        }
        public void Deposit(int depositMoney)
        {
    
            Balance += depositMoney;

        }

        public void Withdraw(int withdrawAmount)
        {
            if(Balance<=0){
                Console.WriteLine("Insufficient Balance");

            }
            else{
            Balance -= withdrawAmount;
            }

        }

    }
}