﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace POLARIS.Skills {
	public static class SkillsCore {

		/// <summary>
		/// Fetches and executes the 'Execute' Method from the respective Class named after the Skill found in the Dialog object inside the 'Skills' Namespace
		/// </summary>
		/// <param name="dialog"></param>
		public static void FetchSkill(Dialog dialog) {

			String skillName = dialog.Phrase[dialog.SkillsIndex[0]];
			skillName = skillName.First().ToString().ToUpper() + skillName.Substring(1);
			Type classType = Type.GetType("POLARIS.Skills." + skillName);

			if (classType == null) {
				Console.WriteLine("WARNING!: Skill '" + skillName + "' recognized but not yet implemented.");
				return;
			}

			if (classType.Name != "SkillsCore") {
				MethodInfo classMethod = classType.GetMethod("Execute");
				Task.Factory.StartNew(() => classMethod.Invoke(null, new object[] { dialog }));
			}
		}
	}
}