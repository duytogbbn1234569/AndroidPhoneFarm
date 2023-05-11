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
    public delegate void OnFailed();

    public class BaseScriptComponent : BaseScript
    {
        public BaseScriptComponent(int maxTry = 1) : base(maxTry) { }

        public Init init = () => { };

        public Wait wait = () => { };

        public Action action = () => { };

        public CanAction canAction = () => true;

        public IsCompleted isCompleted = () => true;

        public IsError isError = () => false;

        public OnCompleted onCompleted = () => { };

        public OnFailed onFailed = () => { };

        protected override void Init()
        {
            init.Invoke();
        }

        protected override void Wait()
        {
            wait.Invoke();
        }

        protected override void Action()
        {
            action.Invoke();
        }

        protected override bool CanAction()
        {
            return canAction.Invoke();
        }

        protected override bool IsCompleted()
        {
            return isCompleted.Invoke();
        }

        protected override bool IsError()
        {
            return isError.Invoke();
        }

        protected override void OnCompleted()
        {
            onCompleted.Invoke();
        }

        protected override void OnFailed()
        {
            onFailed.Invoke();
        }
    }
}
