import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Person } from './models/models';
import { PersonManagerService } from './services/person-manager.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public people: Person[] = [];
  public addEditPerson: Person = { id: 0, firstName: '', lastName: '', dob: new Date(), departmentId: 0 };
  constructor(private http: HttpClient, private service: PersonManagerService) { }

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
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: new Date(), departmentId: 0 };
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
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: new Date(), departmentId: 0 };
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onDelete(id: number) {
    this.http.delete(`https://localhost:7205/api/person/${id}`).subscribe(
      (result) => {
        const index = this.people.findIndex((p) => p.id === id);

        console.warn(index);
        this.people.slice(index);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: new Date(), departmentId: 0 };
      },
      (error) => {
        console.error(error);
      }
    );
  }

  selectPerson(person: Person) {
    this.addEditPerson = person;
  }

  clearPerson() {
    this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: new Date(), departmentId: 0 };
  }
}
