import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../core/data.service';
import { CommonVariable } from '../../../common/common.variable';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent implements OnInit {

  pageIndex: number = 1;
  pageSize: number = -1;
  totalNews: number = -1;
  keyword: string = "";
  newsData: any = [];


  constructor(private _dataService: DataService) { }


  ngOnInit(): void {
    this.LoadData()
  }
  public LoadData() {
    this._dataService.get(`/api/News/View?Keyword=${this.keyword}&pageIndex=${this.pageIndex}`).subscribe(response => {
      console.log(response);
      this.newsData = response.resultObj.items;
      this.pageIndex = response.resultObj.pageIndex;
      this.pageSize = response.resultObj.pageSize;
      this.totalNews = response.resultObj.totalRecords;
    })
  }
  onPageIndexChange(pageIndex: number) {
    this.pageIndex = pageIndex;
    this.LoadData();
  }

}
