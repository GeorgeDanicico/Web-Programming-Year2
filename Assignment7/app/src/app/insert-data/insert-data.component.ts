import { Component, OnInit } from '@angular/core';
import { Service } from '../genericservice.service';

@Component({
  selector: 'app-insert-data',
  templateUrl: './insert-data.component.html',
  styleUrls: ['./insert-data.component.css'],
  providers: [Service],
})
export class InsertDataComponent implements OnInit {
  id: string = '';
  city: string = '';
  country: string = '';
  description: string = '';
  tourists: string = '';
  estimated_cost: string = '';

  constructor(private myService: Service) {}

  ngOnInit(): void {
  }

  onSave(event: any) {
    event.preventDefault();
    const data = { 
      id: this.id, city: this.city, country: this.country, description: this.description, 
      tourists: this.tourists, estimated_cost: this.estimated_cost
    };

    this.myService.addDestination(data);
  }

}
