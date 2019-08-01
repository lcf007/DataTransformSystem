using System;
using System.Linq;

namespace DataTransformSystem
{
    public class AccountAction
    {
        public Action<AccountStandard,string>[] Actions;

        public void MapActions(string[] fields)
        {
            if (fields == null || fields.Length == 0) return;
            Actions = new Action<AccountStandard, string>[fields.Length];
            for (var i = 0; i < fields.Length; i++)
            {
                var fieldNoSpace = fields[i].Trim().Replace(" ", "");
                Actions[i] = MatchAction(fieldNoSpace);
            }
        }

        //TODO, Now only using source file field to find Action, may need to change if one field have more than one meaning.
        private static Action<AccountStandard, string> MatchAction(string field)
        {
            return string.IsNullOrWhiteSpace(field) ? null : Mapping.MappingActions.FirstOrDefault(mappingAction => mappingAction.Method.Name.StartsWith($"{field}"));
        }

    }
}
