using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BionicInventory.API.Commons {
    public class MvcControllerDiscovery : ISystemFunctionDiscovery {
        private List<MvcControllerInfo> _mvcControllers;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public MvcControllerDiscovery (IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IEnumerable<MvcControllerInfo> GetFunctions () {
            if (_mvcControllers != null)
                return _mvcControllers;

            _mvcControllers = new List<MvcControllerInfo> ();

            var items = _actionDescriptorCollectionProvider
                .ActionDescriptors.Items
                .Where (descriptor => descriptor.GetType () == typeof (ControllerActionDescriptor))
                .Select (descriptor => (ControllerActionDescriptor) descriptor)
                .GroupBy (descriptor => descriptor.ControllerTypeInfo.FullName)
                .ToList ();

            foreach (var actionDescriptors in items) {
                if (!actionDescriptors.Any ())
                    continue;

                var actionDescriptor = actionDescriptors.First ();
                var controllerTypeInfo = actionDescriptor.ControllerTypeInfo;
                var currentController = new MvcControllerInfo {
                    AreaName = controllerTypeInfo.GetCustomAttribute<AreaAttribute> ()?.RouteValue,
                    DisplayName =
                    controllerTypeInfo.GetCustomAttribute<DisplayNameAttribute> ()?.DisplayName,
                    Name = actionDescriptor.ControllerName,
                };

                var actions = new List<MvcActionInfo> ();
                foreach (var descriptor in actionDescriptors.GroupBy (a => a.ActionName).Select (g => g.First ())) {
                    var methodInfo = descriptor.MethodInfo;
                    var r = methodInfo.GetCustomAttribute<HttpPostAttribute> ();

                    MvcActionInfo actionInfo = new MvcActionInfo () {
                        controllerId = currentController.Id,
                        name = descriptor.ActionName,
                        displayName =
                        methodInfo.GetCustomAttribute<DisplayNameAttribute> ()?.DisplayName,
                    };

     /*                if (methodInfo.GetCustomAttribute<HttpPostAttribute> () != null) {
                        actionInfo.type = "Create";
                    } else if (methodInfo.GetCustomAttribute<HttpGetAttribute> () != null) {
                        actionInfo.type = "Read";
                    } else if (methodInfo.GetCustomAttribute<HttpPutAttribute> () != null) {
                        actionInfo.type = "Update";
                    } else if (methodInfo.GetCustomAttribute<HttpDeleteAttribute> () != null) {
                        actionInfo.type = "Delete";
                    } */
                    actions.Add (actionInfo);

                }

                currentController.Actions = actions;
                _mvcControllers.Add (currentController);
            }

            return _mvcControllers;
        }
    }
}