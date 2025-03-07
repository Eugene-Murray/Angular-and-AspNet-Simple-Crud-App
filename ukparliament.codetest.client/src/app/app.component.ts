import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface People {
  firstName: string;
  secondName: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public people: string[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('https://localhost:7205/api/person').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );

    //https://localhost:7205/api/Person
    this.http.get<string[]>('https://localhost:7205/api/values').subscribe(
      (result) => {
        console.warn(result);
        this.people = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'ukparliament.codetest.client';
}
