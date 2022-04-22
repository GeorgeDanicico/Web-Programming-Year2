import { Component, OnInit } from '@angular/core';
import { Service } from '../genericservice.service';

@Component({
  selector: 'app-update-data',
  templateUrl: './update-data.component.html',
  styleUrls: ['./update-data.component.css']
})
export class UpdateDataComponent implements OnInit {
  id: string = '';
  estimated_cost: string = '';

  constructor(private myService: Service) { }

  ngOnInit(): void {
  }

  onUpdate() {
    const data = {
      id: this.id,
      estimated_cost: this.estimated_cost,
    }

    this.myService.updateDestination(data);
  }

}
