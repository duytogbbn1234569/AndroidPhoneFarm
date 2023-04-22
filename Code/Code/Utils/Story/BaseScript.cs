using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Utils.Story
{
    public delegate void Action();
    public delegate bool CanAction();
    public delegate void Wait();
    public delegate void OnCompleted();
    public delegate bool IsCompleted();
    public delegate bool IsError();
    public delegate bool Candidate();
    public delegate void Init();

    public class BaseScript
    {
        private int tryCounter;

        public BaseScript(int maxTry = 1)
        {
            this.tryCounter = maxTry;
        }

        public bool RunScript()
        {
            init.Invoke();
            while (!isError.Invoke() && !canAction.Invoke())
            {
                wait.Invoke();
                if (--tryCounter == 0)
                {
                    break;
                }
            }
            if (canAction.Invoke())
            {
                action.Invoke();
                if (isCompleted.Invoke())
                {
                    onCompleted.Invoke();
                    return chooseAndRunNextScript();
                } else return true;
            }
            return false;
        }

        public Init init = () => { };

        public Wait wait = () => { };

        public Action action = () => { };

        public CanAction canAction = () => true;

        public IsCompleted isCompleted = () => true;

        public IsError isError = () => false;

        public OnCompleted onCompleted = () => { };

        private List<Candidate> _candidates = new List<Candidate>();
        private List<BaseScript> _scripts = new List<BaseScript>();

        public BaseScript AddNext(BaseScript nextScript, Candidate choose)
        {
            this._candidates.Add(choose);
            this._scripts.Add(nextScript);
            return this;
        }

        public BaseScript AddNext(BaseScript nextScript)
        {
            this._candidates.Add(() => true);
            this._scripts.Add(nextScript);
            return this;
        }

        private bool chooseAndRunNextScript()
        {
            int index = 0;
            foreach (Candidate candidate in this._candidates)
            {
                if (candidate.Invoke())
                {
                    break;
                }
                ++index;
            }
            if (index != this._candidates.Count)
            {
                return this._scripts[index].RunScript();
            }
            else return this._candidates.Count == 0;
        }

        internal BaseScript AddNext(object clickOwnUsernameAndChooseNext)
        {
            throw new NotImplementedException();
        }
    }
}
