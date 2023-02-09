import HttpClient from './http-client';
import { JobPosition } from '../models/JobPosition';

export default class MainApi extends HttpClient {
  public constructor() {
    super('http://localhost:5048/api/v1');
  }

  public getJobPositions = () =>
    this.instance.get<JobPosition[]>('/jobposition');

  public getJobPosition = (id: string) =>
    this.instance.get<JobPosition>(`/jobposition/${id}`);
}
