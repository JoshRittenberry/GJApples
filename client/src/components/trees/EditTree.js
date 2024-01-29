import { useEffect, useState } from "react"
import { Footer } from "../Footer"
import "../stylesheets/editTree.css"
import { useParams } from "react-router-dom"
import { getTreeById } from "../../managers/treeManager"
import { Button, Form, FormGroup, FormText, Input, Label } from "reactstrap"
import { getAppleVarieties } from "../../managers/appleManager"

export const EditTree = ({ loggedInUser }) => {
    const [tree, setTree] = useState({})
    const [appleVarieties, setAppleVarieties] = useState([])
    const [update, setUpdate] = useState({})

    const treeId = useParams().id

    useEffect(() => {
        getTreeById(treeId).then(res => {
            setTree(res)
            setUpdate({
                appleVarietyId: res.appleVarietyId,
                datePlanted: res.datePlanted,
                dateRemoved: res.dateRemoved,
            })
        })
        getAppleVarieties().then(setAppleVarieties)
    }, [])

    const changeDateRemoved = () => {
        if (update.dateRemoved == null) {
            let newUpdate = { ...update }
            newUpdate.dateRemoved = new Date().toISOString()
            setUpdate(newUpdate)
        } else if (update.dateRemoved != null) {
            let newUpdate = { ...update }
            newUpdate.dateRemoved = null
            setUpdate(newUpdate)
        }
    }

    return (
        <>
            <div className="edittree">
                <header className="edittree_header">
                    <div className="edittree_header_top">
                        <h1>Tree Editor (Tree #{tree.id})</h1>
                    </div>
                </header>
                <section className="edittree_body">
                    <Form>
                        <FormGroup>
                            <Label for="appleVariety">
                                Apple Variety
                            </Label>
                            <Input
                                id="appleVariety"
                                name="select"
                                type="select"
                            >
                                {appleVarieties.map(av => {
                                    return (
                                        <option key={av.id} selected={av.id == update.appleVarietyId}>
                                            {av.type}
                                        </option>
                                    )
                                })}
                            </Input>
                        </FormGroup>
                        <FormGroup>
                            <Label for="datePlanted">
                                Date Planted
                            </Label>
                            <Input
                                id="datePlanted"
                                name="datePlanted"
                                placeholder="date placeholder"
                                type="date"
                                defaultValue={update.datePlanted ? update.datePlanted.substring(0, 10) : ''}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label for="dateRemoved">
                                Date Removed
                            </Label>
                            <Input
                                id="dateRemoved"
                                name="dateRemoved"
                                placeholder="date placeholder"
                                type="date"
                                defaultValue={update.dateRemoved ? update.dateRemoved.substring(0, 10) : ''}
                                onChange={event => {
                                    event.preventDefault()
                                    let newUpdate = { ...update }
                                    newUpdate.dateRemoved = new Date().toISOString()
                                    setUpdate(newUpdate)
                                }}
                            />
                        </FormGroup>
                    </Form>
                </section>
                <div className="edittree_footer">
                    <Button className="edittree_footer_button">
                        Submit
                    </Button>
                    <Button className="edittree_footer_button">
                        Cancel
                    </Button>
                </div>
            </div>
            <Footer />
        </>
    )
}