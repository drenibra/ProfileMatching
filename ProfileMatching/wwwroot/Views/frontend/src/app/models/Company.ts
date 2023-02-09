import { JobPosition } from './JobPosition';
import { Recruiter } from './Recruiter';

export interface Company {
  id: number;
  name: string;
  location: string;
  logo: string;
  recruiters: Recruiter[];
  JobPositions: JobPosition[];
}
