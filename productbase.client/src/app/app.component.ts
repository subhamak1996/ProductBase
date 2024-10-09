import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent  {
  //Start @input parant to child
  data = "Hi this is parant to child";
  //End @input parant to child
  //Start @output child to parant
  outputresult = "X";
  outputdata(item:string) {
    this.outputresult = item;
  }
  //End @output child to parant
  public forecasts: WeatherForecast[] = [];
  
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'productbase.client';
}
