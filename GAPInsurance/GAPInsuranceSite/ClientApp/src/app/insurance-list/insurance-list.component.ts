import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Insurance } from '../models/Insurance';

@Component({
  selector: 'app-insurance-list',
  templateUrl: './insurance-list.component.html',
  styleUrls: ['./insurance-list.component.css']
})
export class InsuranceListComponent implements OnInit {

  data: Insurance[] = [];

  constructor(private api: ApiService) {
  }

  ngOnInit() {

    this.api.getInsurances()
      .subscribe(res => {
        this.data = res;
      }, err => {
        console.log(err);
      });

    console.log(this.data);
  }

}
