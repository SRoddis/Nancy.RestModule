using System;
using System.Threading;
using System.Threading.Tasks;
using Nancy.RestModule.Models;

namespace Nancy.RestModule
{
    public abstract class RestModuleAsync : AbstractRestModule
    {
        protected RestModuleAsync(string path)
            : base(path)
        {
        }

        #region Protected Handler

        protected void GetHandler(
            string path,
            Func<Task<ResponseModel>> controllerAction)
        {
            Get[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction).ConfigureAwait(false);
        }

        protected void GetHandler<TGetRequest>(
            string path,
            Func<TGetRequest, Task<ResponseModel>> controllerAction)
        {
            Get[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction, ctx).ConfigureAwait(false);
        }

        protected void GetHandler<TGetRequest>(
            string path,
            Func<TGetRequest, CancellationToken, Task<ResponseModel>> controllerAction)
        {
            Get[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction, ctx).ConfigureAwait(false);
        }

        protected void PostHandler<TPostRequest>(
            string path,
            Func<TPostRequest, Task<ResponseModel>> controllerAction)
        {
            Post[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction, ctx).ConfigureAwait(false);
        }

        protected void PostHandler(
            string path,
            Func<Task<ResponseModel>> controllerAction)
        {
            Post[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction).ConfigureAwait(false);
        }

        protected void PutHandler<TPutRequest>(
            string path,
            Func<TPutRequest, Task<ResponseModel>> controllerAction)
        {
            Put[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction, ctx).ConfigureAwait(false);
        }


        protected void DeleteHandler<TDeleteRequest>(
            string path,
            Func<TDeleteRequest, Task<ResponseModel>> controllerAction)
        {
            Delete[path, true] =
                async (context, ctx) =>
                    await RequestHandler(controllerAction, ctx).ConfigureAwait(false);
        }

        #endregion

        #region Private Handler

        private async Task<object> RequestHandler(
            Func<Task<ResponseModel>> controllerAction)
        {
            ResponseModel response = await controllerAction().ConfigureAwait(false);

            return DoNegotiate(response);
        }

        private Task<object> RequestHandler<TRequest>(
            Func<TRequest, Task<ResponseModel>> controllerAction,
            CancellationToken cancellationToken)
        {
            return ExecuteControllerAction<TRequest>((request, ctx) => controllerAction(request), cancellationToken);
        }

        private Task<object> RequestHandler<TRequest>(
            Func<TRequest, CancellationToken, Task<ResponseModel>> controllerAction,
            CancellationToken cancellationToken)
        {
            return ExecuteControllerAction(controllerAction, cancellationToken);
        }

        #endregion

        protected virtual async Task<object> ExecuteControllerAction<TRequest>(
            Func<TRequest, CancellationToken, Task<ResponseModel>> controllerAction,
            CancellationToken cancellationToken)
        {
            var model = DoBind<TRequest>();

            DoValidate(model);

            ResponseModel response = await controllerAction(model, cancellationToken).ConfigureAwait(false);

            return DoNegotiate(response);
        }
    }
}