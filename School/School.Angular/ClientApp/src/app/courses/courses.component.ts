import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent {
  public courses: Course[];
  public coursesAll: Course[];
  isFilterApplied: boolean = false;
  id: number;

  constructor(http: HttpClient, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>(baseUrl + 'courses').subscribe(result => {
      this.coursesAll = result;
      this.courses =result;

      this.id = Number.parseInt(route.snapshot.params["id"]);
      if(this.id)
      {
        this.filterById(this.id);
      }
    }, error => console.error(error));
  }

  filterById(id: number)
  {
    this.courses = this.coursesAll.filter(c=>c.id === id);
  }

  filter(topicId: number): void
  {
    this.courses = this.coursesAll.filter(c=>c.topicId === topicId);
    this.isFilterApplied=true;
  }

  clearFilter()
  {
    this.isFilterApplied=false;
    this.courses = this.coursesAll;
  }
}

interface Course {
  id: number;
  title: string;
  topicId: number;
  topicName: string;
  description: string;
}
