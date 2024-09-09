using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MfcWeb.Models
{
	public class ListBpkbModel
	{
        public int agreement_number { get; set; }
        public string? bpkb_no { get; set; }
        public string? branch_id { get; set; }
        public string? bpkb_date { get; set; }
        public string? faktur_no { get; set; }
        public string? faktur_date { get; set; }
        public int location_id { get; set; }
        public string? police_no { get; set; }
        public string? bpkb_date_in { get; set; }
        public string? created_by { get; set; }
        public string? created_on { get; set; }
        public string? last_updated_by { get; set; }
        public string? last_updated_on { get; set; }
    }
}

