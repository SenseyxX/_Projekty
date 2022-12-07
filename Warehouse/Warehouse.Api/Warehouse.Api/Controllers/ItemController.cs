using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Warehouse.Application.Contracts.Commands.Item;
using Warehouse.Application.Dtos.Item;
using Warehouse.Application.Handlers;
using Warehouse.Domain.Item;

namespace Warehouse.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route(RoutePattern)]
    public class ItemController : Controller
    {
        private readonly ItemHandler _itemHandler;

        public ItemController(ItemHandler itemHandler)
        {
            _itemHandler = itemHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync(
            CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{itemId:guid}")]
        public async Task<ActionResult<FullItemDto>> GetItemAsync(
        [FromRoute] Guid itemId,
        CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemAsync(itemId,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(
        [FromBody] CreateItemCommand createItemCommand,
        CancellationToken cancellationToken)
        {
            await _itemHandler.CreateItemAsync(createItemCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("import")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateItemsAsync(
            IFormFile file,
            CancellationToken cancellationToken)
        {
            using var streamReader = new StreamReader(file.OpenReadStream());
            var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var records = reader.GetRecords<ItemModel>();

            var command = new CreateItemsCommand
            {
                Models = records
            };

            await _itemHandler.CreateItemsAsync(command, cancellationToken);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("export")]
        public async Task<FileResult> ExportItemsAsync(CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemsAsync(cancellationToken);

            using var memoryStream = new MemoryStream();
            await using var writer = new StreamWriter(memoryStream);
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            await csv.WriteRecordsAsync((IEnumerable)result, cancellationToken);

            var serializedData = memoryStream.ToArray();
            return File(serializedData, "text/csv", $"items-{DateTime.Now:yyyy-MM-dd hh:mm}");
        }

        [HttpDelete("{itemId:guid}")]
        public async Task<IActionResult> DeleteItemAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)

        {
            await _itemHandler.DeleteItemAsync(itemId, cancellationToken);
            return Ok();
        }

        [HttpPut("{itemId:guid}")]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            updateItemCommand.ItemId = itemId;

            await _itemHandler.UpdateItemAsync(updateItemCommand, cancellationToken);
            return Ok();
        }

        [HttpGet("{itemId:guid}/loan-history")]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetItemLoanHistoryAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemLoanHistoriesAsync(itemId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{itemId:guid}/loan")]
        public async Task<IActionResult> LoanItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] LoanItemCommand loanItemCommand,
            CancellationToken cancellationToken)
        {
            loanItemCommand.ItemId = itemId;

            await _itemHandler.LoanItemAsync(loanItemCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{itemId:guid}/quality")]
        public async Task<IActionResult> UpdateItemQualityAsync(
            [FromRoute] Guid itemId,
            [FromBody] UpdateItemQualityCommand updateItemQualityCommand,
            CancellationToken cancellationToken)
        {
            updateItemQualityCommand.ItemId = itemId;

            await _itemHandler.UpdateItemQualityAsync(updateItemQualityCommand, cancellationToken);
            return Ok();
        }
    }
}
