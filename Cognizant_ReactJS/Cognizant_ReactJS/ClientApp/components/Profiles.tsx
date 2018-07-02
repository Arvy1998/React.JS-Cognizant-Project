import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface Profile {
    id: number;
    name: string;
    surname: string;
    age: number;
}

interface ProfileState {
    profiles: Profile[];
    loading: boolean;
}

export class Profiles extends React.Component<RouteComponentProps<{}>, ProfileState> {
    constructor() {
        super();

        this.state = { loading: true, profiles: [] };

        fetch('api/profile')
            .then(response => response.json() as Promise<Profile[]>)
            .then(data => {
                this.setState({ profiles: data, loading: false });
                console.log(data);
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p>Loading...</p>
            : ProfilesTable(this.state.profiles);
        return <div>
            <h1>Profiles</h1>
            {contents}
        </div>;
    }
}

const ProfilesTable = (profiles: Profile[]) => {
    return <table className='table'>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Surname</th>
                <th>Age</th>
            </tr>
        </thead>
        <tbody>
            {profiles.map(profile => 
                <tr key={profile.id}>
                    <td>{profile.id}</td>
                    <td>{profile.name}</td>
                    <td>{profile.surname}</td>
                    <td>{profile.age}</td>
                    </tr>
            )}
        </tbody>
    </table>
}