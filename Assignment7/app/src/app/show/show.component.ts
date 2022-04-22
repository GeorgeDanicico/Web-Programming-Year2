import { Component, OnInit } from '@angular/core';
import { Service } from '../genericservice.service';

type IDestination = {
  id: number,
  description: string,
  city: string,
  country: string,
  tourists_target: string,
  estimated_cost: number,
   
}

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  destinations: IDestination[] = [];
  pageSize: number = 4;
  page: number = 1;
  totalPages: number = 0;
  currentIndex = -1;
  convert = (destination: any) => {
    return 'ID: ' + destination.id + '  City: ' + destination.city + 
      "Country: " + destination.country + ' Estimated Cost: ' + destination.estimated_cost;
  }

  constructor(private myService: Service) {
    myService.fetchDestinations().subscribe((data) => {
      console.log(data);
      this.destinations = data;
    });
    this.totalPages = Math.ceil(this.destinations.length / 4);

  }

  display(destination: any) {
    return destination.id;
  }

  ngOnInit(): void {
  }

  handlePageChange(event: any) {
    this.page = event;
  }

}
