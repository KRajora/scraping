import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScrapServiceService {

  constructor(private _http: HttpClient) { }

  public getScrapingDetails(url:string):Observable<any>{
    return this._http.get(`/api/Scrape/GetSiteScrapeDetails?url=${url}`);
  }
}
