﻿namespace MyTested.AspNetCore.Mvc.Builders.Base
{
    using And;
    using Contracts.And;
    using Contracts.Base;
    using Internal.TestContexts;
    using Utilities;

    /// <summary>
    /// Base class for all test builders with action result.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET Core MVC controller.</typeparam>
    public abstract class BaseTestBuilderWithActionResult<TActionResult>
        : BaseTestBuilderWithInvokedAction, IBaseTestBuilderWithActionResult<TActionResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestBuilderWithActionResult{TActionResult}"/> class.
        /// </summary>
        /// <param name="testContext"><see cref="ControllerTestContext"/> containing data about the currently executed assertion chain.</param>
        protected BaseTestBuilderWithActionResult(ControllerTestContext testContext)
            : base(testContext)
        {
        }

        /// <summary>
        /// Gets the action result which will be tested.
        /// </summary>
        /// <value>Action result to be tested.</value>
        public TActionResult ActionResult => this.TestContext.MethodResultAs<TActionResult>();
        
        /// <summary>
        /// Initializes new instance of builder providing AndAlso method.
        /// </summary>
        /// <returns>Test builder of type <see cref="IAndActionResultTestBuilder{TActionResult}"/>.</returns>
        public IAndActionResultTestBuilder<TActionResult> NewAndTestBuilder()
        {
            return new AndActionResultTestBuilder<TActionResult>(this.TestContext);
        }

        /// <summary>
        /// Creates new <see cref="AndTestBuilderWithActionResult{TActionResult}"/>.
        /// </summary>
        /// <returns>Base test builder of type <see cref="IBaseTestBuilderWithActionResult{TActionResult}"/>.</returns>
        public IBaseTestBuilderWithActionResult<TActionResult> NewAndTestBuilderWithActionResult()
            => new AndTestBuilderWithActionResult<TActionResult>(this.TestContext);

        /// <summary>
        /// Returns the actual action result casted as dynamic type.
        /// </summary>
        /// <returns>Object of dynamic type.</returns>
        protected dynamic GetActionResultAsDynamic()
        {
            return this.ActionResult.GetType().CastTo<dynamic>(this.ActionResult);
        }
    }
}
