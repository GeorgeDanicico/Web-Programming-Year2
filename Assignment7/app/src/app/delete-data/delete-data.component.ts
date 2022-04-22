import { Component, OnInit } from '@angular/core';
import { Service } from '../genericservice.service';

@Component({
  selector: 'app-delete-data',
  templateUrl: './delete-data.component.html',
  styleUrls: ['./delete-data.component.css']
})
export class DeleteDataComponent implements OnInit {

  id: string = '';
  constructor(private myService: Service) { }

  ngOnInit(): void {
  }

  onDelete() {
    this.myService.deleteDestination(this.id);
  }

}
