using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Utils.Story
{
    public class BaseScript
    {
        protected int tryCounter;

        public BaseScript(int maxTry = 1)
        {
            this.tryCounter = maxTry;
        }

        public virtual bool RunScript()
        {
            Init();
            bool canAction = false;
            bool isError = false;
            while (!(isError = IsError()) && !(canAction = CanAction()))
            {
                Wait();
                if (--tryCounter == 0)
                {
                    break;
                }
            }
            if (!isError && canAction)
            {
                Action();
                if (IsCompleted())
                {
                    OnCompleted();
                    return chooseAndRunNextScript();
                }
                else
                {
                    OnFailed();
                    return false;
                }
            }
            return false;
        }

        protected virtual void Init()
        {
        }

        protected virtual void Wait()
        {
        }

        protected virtual void Action()
        {
        }

        protected virtual bool CanAction()
        {
            return true;
        }

        protected virtual bool IsCompleted()
        {
            return true;
        }

        protected virtual bool IsError()
        {
            return false;
        }

        protected virtual void OnCompleted()
        {
        }

        protected virtual void OnFailed()
        {

        }

        public virtual void OnTerminateOrPause()
        {
            this.OnFailed();
        }

        protected List<Candidate> _candidates = new List<Candidate>();
        protected List<BaseScript> _scripts = new List<BaseScript>();

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

        protected virtual bool chooseAndRunNextScript()
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
    }
}
