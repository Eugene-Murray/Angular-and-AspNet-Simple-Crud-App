import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Person, Department } from './models/models';
import { DataService } from './services/data.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public people: Person[] = [];
  public departments: Department[] = [];
  public addEditPerson: Person = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
  constructor(private http: HttpClient, private dataService: DataService) { }


  // Property to bind the selected option
  selectedDepartmentId: number = 0;
  selectedDate: string = '2000-2-4';

  // Method to handle the selection change
  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedDepartmentId = Number(selectElement.value);
    console.log('Selected Person ID:', this.selectedDepartmentId);
  }

  ngOnInit() {
    this.getDepartments()
    this.getPeople();
  }

  getDepartments() {
    this.dataService.getDepartments().subscribe(result => this.departments = result);
  }

  getPeople() {
    this.dataService.getPersons().subscribe(result => this.people = result);

    //this.http.get<Person[]>('https://localhost:7205/api/person').subscribe(
    //  (result) => {
    //    this.people = result;
    //  },
    //  (error) => {
    //    console.error(error);
    //  }
    //);
  }

  addPerson() {
    //this.http.post<Person>('https://localhost:7205/api/person', this.addEditPerson).subscribe(
    //  (result) => {
    //    this.people.push(result);
    //    this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
    //  },
    //  (error) => {
    //    console.error(error);
    //  }
    //);
  }

  editPerson() {
    //this.http.put<Person>(`https://localhost:7205/api/person/${this.addEditPerson.id}`, this.addEditPerson).subscribe(
    //  (result) => {
    //    this.people.push(result);
    //    this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
    //  },
    //  (error) => {
    //    console.error(error);
    //  }
    //);
  }

  onDelete(id: number) {
    //this.http.delete(`https://localhost:7205/api/person/${id}`).subscribe(
    //  (result) => {
    //    const index = this.people.findIndex((p) => p.id === id);

    //    console.warn(index);
    //    this.people.slice(index);
    //    this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
    //  },
    //  (error) => {
    //    console.error(error);
    //  }
    //);
  }

  selectPerson(person: Person) {
    this.addEditPerson = person;
  }

  clearPerson() {
    this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
  }
}
