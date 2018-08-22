﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vk_web_mock.Models;

namespace vk_web_mock.Controllers
{
    [ApiController]
    public class VirtualKubeletWebController : Controller
    {
        private readonly ILogger _logger;
        public VirtualKubeletWebController(ILogger<VirtualKubeletWebController> logger)
        {
            _logger = logger;
        }

        [HttpGet("capacity")]
        public IActionResult GetCapacity()
        {
            return Json(new {
                cpu = "20",
                memory = "100Gi",
                pods ="20"
            });
        }

        [HttpGet("nodeConditions")]
        public IActionResult GetNodeConditions(){
            DateTime utcNow = DateTime.UtcNow;

            return base.Json(new [] {
                new {
                    lastHeartbeatTime = utcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    lastTransitionTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    message= "At your service",
                    reason = "KubeletReady",
                    status = "True",
                    type="Ready"
                }

        //         {
		// 	Type:               "Ready",
		// 	Status:             v1.ConditionTrue,
		// 	LastHeartbeatTime:  metav1.Now(),
		// 	LastTransitionTime: metav1.Now(),
		// 	Reason:             "KubeletReady",
		// 	Message:            "kubelet is ready.",
		// },
		// {
		// 	Type:               "OutOfDisk",
		// 	Status:             v1.ConditionFalse,
		// 	LastHeartbeatTime:  metav1.Now(),
		// 	LastTransitionTime: metav1.Now(),
		// 	Reason:             "KubeletHasSufficientDisk",
		// 	Message:            "kubelet has sufficient disk space available",
		// },
		// {
		// 	Type:               "MemoryPressure",
		// 	Status:             v1.ConditionFalse,
		// 	LastHeartbeatTime:  metav1.Now(),
		// 	LastTransitionTime: metav1.Now(),
		// 	Reason:             "KubeletHasSufficientMemory",
		// 	Message:            "kubelet has sufficient memory available",
		// },
		// {
		// 	Type:               "DiskPressure",
		// 	Status:             v1.ConditionFalse,
		// 	LastHeartbeatTime:  metav1.Now(),
		// 	LastTransitionTime: metav1.Now(),
		// 	Reason:             "KubeletHasNoDiskPressure",
		// 	Message:            "kubelet has no disk pressure",
		// },
		// {
		// 	Type:               "NetworkUnavailable",
		// 	Status:             v1.ConditionFalse,
		// 	LastHeartbeatTime:  metav1.Now(),
		// 	LastTransitionTime: metav1.Now(),
		// 	Reason:             "RouteCreated",
		// 	Message:            "RouteController created a route",
		// },
            });
        }

        [HttpGet("{*unmatched}")]
        public IActionResult Catchall(string unmatched)
        {
            _logger.LogWarning($"Unmatched: {unmatched}");
            return NotFound();
        }
    }
}
