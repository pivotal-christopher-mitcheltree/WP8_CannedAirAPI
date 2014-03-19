using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CannedAirAPI.Models
{
    public class Timesheet
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "starts_at")]
        public string StartsAt { get; set; }

        [JsonProperty(PropertyName = "ends_at")]
        public string EndsAt { get; set; }

        [JsonProperty(PropertyName = "tasks")]
        public List<Task> Tasks { get; set; }
    }

    public class Task
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "hours")]
        public string Hours { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public string ProjectId { get; set; }

        [JsonProperty(PropertyName = "project_task_id")]
        public string ProjectTaskId { get; set; }

        [JsonProperty(PropertyName = "timesheet_id")]
        public string TimesheetId { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}