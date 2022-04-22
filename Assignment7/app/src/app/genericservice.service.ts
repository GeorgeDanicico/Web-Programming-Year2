import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

type IDestination = {
  id: number,
  description: string,
  city: string,
  country: string,
  tourists_target: string,
  estimated_cost: number,
}


@Injectable({
  providedIn: 'root'
})

export class Service {
  private url: string = 'http://localhost:8080/index/'

  constructor(private http: HttpClient) { }

  fetchDestinations() {
    const headers = {
      'content-type' : 'application/json',
      'Access-Control-Allow-Origin':'*',
    };

    return this.http.get<IDestination[]>(this.url + 'getdestinations.php', { 'headers': headers});
  }

  addDestination(data: any) {
    const headers = {
      'content-type' : 'application/json',
      'Access-Control-Allow-Origin':'*',
    };
    const body = JSON.stringify(data);
    console.log(body);

    return this.http.post(this.url + 'add_data.php', body, {'headers': headers}).subscribe(data => {
      console.log(data);
    });;
  }

  deleteDestination(id: string) {
    const headers = {
      'content-type' : 'application/json',
      'Access-Control-Allow-Origin':'*',
    };
    const body = JSON.stringify({ id });

    return this.http.post(this.url + 'delete.php', body, { 'headers': headers}).subscribe(data => {
      console.log(data);
    });
  }

  updateDestination(data: any) {
    const headers = {
      'content-type' : 'application/json',
      'Access-Control-Allow-Origin':'*',
    };
    const body = JSON.stringify(data);
    console.log(body);

    return this.http.post(this.url + 'update.php', body, {'headers': headers}).subscribe(data => {
      console.log(data);
    });;
  }
}
