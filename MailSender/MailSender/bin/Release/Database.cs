using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
	static class Database
	{
		private static readonly EmailsDataContext _emailsDataContext = new
			EmailsDataContext();

		public static IQueryable<Email> Emails => from mail in
				_emailsDataContext.Email
												  select mail;
	}
}
