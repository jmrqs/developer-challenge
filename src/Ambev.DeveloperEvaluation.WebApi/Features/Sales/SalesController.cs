using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.Validators;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Request;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Response;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Validators;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of SalesController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new sale
        /// </summary>
        /// <param name="request">The sale creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a paginated list of sales.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination (default is 1).</param>
        /// <param name="pageSize">The number of items per page (default is 20).</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        /// <returns>A paginated list of sales if found.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSale(int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
        {
            var request = new GetSaleRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var validator = new GetSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (response is null)
                return NotFound(new ApiResponseWithData<GetSaleResponse>
                {
                    Success = false,
                    Message = "Sales not found"
                });

            return Ok(new ApiResponseWithData<List<GetSaleResponse>>
            {
                Success = true,
                Message = "Sales retrieved successfully",
                Data = _mapper.Map<List<GetSaleResponse>>(response)
            });
        }

        /// <summary>
        /// Update a new sale
        /// </summary>
        /// <param name="request">The sale update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale details</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSale([FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (response is null)
                return NotFound(new ApiResponseWithData<UpdateSaleResponse>
                {
                    Success = false,
                    Message = "Sales not found"
                });

            return Created(string.Empty, new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = true,
                Message = "Sale updated successfully",
                Data = _mapper.Map<UpdateSaleResponse>(response)
            });
        }

        /// <summary>
        /// Deletes a sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the sale was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleRequest { Id = id };
            var validator = new DeleteSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = response.Success,
                Message = response.Success ? $"Sale deleted successfully" : "Sale deletion failed"
            });
        }
    }
}