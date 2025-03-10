import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Person {
  id: number;
  firstName: string;
  lastName: string;
  departmentId: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public people: Person[] = [];
  public addEditPerson: Person = { id: 0, firstName: '', lastName: '', departmentId: 0 };
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getPeople();
  }

  getPeople() {
    this.http.get<Person[]>('https://localhost:7205/api/person').subscribe(
      (result) => {
        this.people = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addPerson() {
    this.http.post<Person>('https://localhost:7205/api/person', this.addEditPerson).subscribe(
      (result) => {
        this.people.push(result);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', departmentId: 0 };
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editPerson() {
    this.http.put<Person>(`https://localhost:7205/api/person/${this.addEditPerson.id}`, this.addEditPerson).subscribe(
      (result) => {
        this.people.push(result);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', departmentId: 0 };
      },
      (error) => {
        console.error(error);
      }
    );
  }

  selectPerson(person: Person) {
    this.addEditPerson = person;
  }
}
