/*
 * @CreateTime: Dec 12, 2018 2:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 14, 2018 9:57 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Workstations.Commands.Create;
using BionicInventory.Application.Workstations.Commands.Delete;
using BionicInventory.Application.Workstations.Commands.Update;
using BionicInventory.Application.Workstations.Models;
using BionicInventory.Application.Workstations.Queries.Collection;
using BionicInventory.Application.Workstations.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Workstations {

    [InventoryAPI ("productions/workstations")]
    public class WorkstationsController : Controller {
        private readonly IMediator _Mediator;

        public WorkstationsController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/productions/workstations
        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<WorkstationGroupView>>> GetAllWorkstationGroups () {

            var workstations = await _Mediator.Send (new WorkstationGroupListQuery ());

            return StatusCode (200, workstations);
        }

        // api/productions/workstations/1
        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WorkstationGroupDetailView>> GetWorkstationGroupDetail (uint id, string type = "detail") {
            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                Object workStationGroup;

                if (type.ToUpper () == "DETAIL") {
                    workStationGroup = await _Mediator.Send (new SingleWorkstationGroupDetailQuery () { Id = id });
                } else {
                    workStationGroup = await _Mediator.Send (new SingleWorkstationGroupViewQuery () { Id = id });
                }

                return StatusCode (200, workStationGroup);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        // api/productions/workstations/stations
        [HttpGet ("stations")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<WorkstationView>>> GetWorkstation () {

            var stations = await _Mediator.Send (new WorkstationListQuery ());

            return StatusCode (200, stations);
        }

        // api/productions/workstations/stations/13
        [HttpGet ("stations/{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WorkstationView>> GetWorkstationDetail (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                var station = await _Mediator.Send (new SingleWorkstationQuery () { Id = id });

                return StatusCode (200, station);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/productions/workstations
        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WorkstationView>> CreateWorkstationGroup ([FromBody] NewWorkStationGroupDto workStationGroup) {

            if (workStationGroup == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            await _Mediator.Send (workStationGroup);

            return StatusCode (201);
        }

        // api/productions/workstations/1
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateWorkstationGroup (uint id, [FromBody] UpdatedWorkStationGroupDto updatedWorkStationGroup) {

            try {

                if (updatedWorkStationGroup == null || id != updatedWorkStationGroup.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedWorkStationGroup);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/productions/workstations/1
        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteWorkstationGroup (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedWorkstationGroupDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/productions/workstations/1/stations
        [HttpPost ("{id}/stations")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WorkstationView>> CreateWorkstation (uint? id, [FromBody] NewWorkstationDto workstation) {

            try {
                if (workstation == null || id != workstation.GroupId) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (workstation);

                return StatusCode (201);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        // api/productions/workstations/1/stations/13
        [HttpPut ("{id}/stations/{stationId}")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateWorkstation (uint id, uint stationId, [FromBody] UpdatedWorkstationDto workstation) {

            try {
                if (workstation == null || id != workstation.GroupId || stationId != workstation.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (workstation);

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        // api/productions/1/stations/13
        [HttpDelete ("stations/{stationId}")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteWorkstation (uint stationId) {

            try {
                if ( stationId == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedWorkstationDto () { Id = stationId });

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }
    }
}