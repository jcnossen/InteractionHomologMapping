using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteractionMapping
{
	public class WizardState
	{
		public InteractionSet set;
		public PartList partList;
		public string[] speciesList;
		public StringDatabaseSearch.dbSpecies species;
	}
	
	public interface IWizardPage
	{
		void InitWizard(WizardState state);
	}
}
