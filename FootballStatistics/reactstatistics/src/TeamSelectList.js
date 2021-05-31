import { Component } from "react";
import { Form } from "react-bootstrap"

export class TeamSelectList extends Component {
    render() {
        return (
            <Form onChange={this.props.teamChangedHandler}>
                <Form.Label>Team for players statistics    </Form.Label>
                <Form.Control as="select" custom>
                    {this.props.teams.map(team => (
                        <option key={team.id} value={team.id}>{team.name}</option>
                    ))}
                </Form.Control>
            </Form >
        )
    }
}