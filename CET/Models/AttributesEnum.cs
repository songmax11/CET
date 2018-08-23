using System;

namespace CET.Models
{
	public class AttributesEnum
	{
		public enum TicketTypesEnum
		{
			Bug,
			Enhencement,
			NewTool
		}

		public enum UrgenciesEnum
		{
			Regular,
			Important,
			Critital
		}

		public enum StatusesEnum
		{
			Defined,
			InProgress,
			Completed,
			Accepted
		}

		public enum ApplicationsEnum
		{
			TheGrid,
			Sirfis,
			Approval,
			Supplier
		}
	}
}

